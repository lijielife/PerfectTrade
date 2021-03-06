#!/bin/bash
#
# install.sh
#
# Installs a Unix-like 'pt' command as a symbolic link in $HOME/bin.
# To un-install PerfectTrade, delete $HOME/PerfectTrade and $HOME/bin/pt.
#
#
# COPYRIGHT (C) 2011 AND ALL RIGHTS RESERVED BY
# MARC WEIDLER, ULRICHSTR. 12/1, 71672 MARBACH, GERMANY (MARC.WEIDLER@WEB.DE).
#
# ALL RIGHTS RESERVED. THIS SOFTWARE AND RELATED DOCUMENTATION ARE PROTECTED BY
# COPYRIGHT RESTRICTING ITS USE, COPYING, DISTRIBUTION, AND DECOMPILATION. NO PART
# OF THIS PRODUCT OR RELATED DOCUMENTATION MAY BE REPRODUCED IN ANY FORM BY ANY
# MEANS WITHOUT PRIOR WRITTEN AUTHORIZATION OF MARC WEIDLER OR HIS PARTNERS, IF ANY.
# UNLESS OTHERWISE ARRANGED, THIRD PARTIES MAY NOT HAVE ACCESS TO THIS PRODUCT OR
# RELATED DOCUMENTATION. SEE LICENSE FILE FOR DETAILS.
#
# THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
# ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
# WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
# IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
# INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
# BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
# DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
# LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
# OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
# OF THE POSSIBILITY OF SUCH DAMAGE. THE ENTIRE RISK AS TO THE QUALITY AND
# PERFORMANCE OF THE PROGRAM IS WITH YOU. SHOULD THE PROGRAM PROVE DEFECTIVE,
# YOU ASSUME THE COST OF ALL NECESSARY SERVICING, REPAIR OR CORRECTION.
#
#set -x

#
# Check mono installation
#
MONOVER=`mono --version | grep version | awk -F" " '{print $5}'`
MONOVER1=`echo $MONOVER | awk -F"." '{print $1}'`
MONOVER2=`echo $MONOVER | awk -F"." '{print $2}'`
if [[ "$MONOVER" == "" ]]
then
   echo "No mono runtime installed."
   exit 1
else
   if [[ $MONOVER1 < 2 ]] || [[ $MONOVER2 < 6 ]]
   then
     echo "PerfectTrade needs Mono 2.6 or higher. Installed is version $MONOVER."
     exit 1
   fi
fi

#
# Install facade frontend
#
mkdir -p $HOME/bin
rm    -f $HOME/bin/pt
ln    -s $HOME/PerfectTrade/perfecttrade.sh $HOME/bin/pt

echo "Installation of 'pt' in '$HOME/bin' done."

